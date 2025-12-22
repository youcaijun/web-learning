package com.hello.controller;

import com.google.gson.Gson;
import com.hello.app.redisClient;
import org.json.JSONObject;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;
import redis.clients.jedis.params.ScanParams;
import redis.clients.jedis.resps.ScanResult;

import java.util.ArrayList;
import java.util.List;

@RestController
@RequestMapping("/redis")
public class redisController {
    @Autowired
    private redisClient client;

    /**
     * Redis get key
     * *
     */
    @GetMapping("/get")
    public String getKey(@RequestParam String key) {
        String result = null;
        try {
            result = client.get(key);
        } catch (Exception e) {
            System.out.println("发生异常: " + e.getMessage());
        } finally {
            client.close();
        }
        return result;
    }

    /**
     * Redis set key
     * Body
     * {
     * key:'',
     * value:''
     * }
     */
    @PostMapping("/set")
    public String setKey(@RequestBody String Body) {
        String key = null;
        String value = null;
        String result = null;
        try {
            JSONObject jsonObject = new JSONObject(Body);
            key = jsonObject.getString("key");
            value = jsonObject.getString("value");
            result = client.set(key, value);
        } catch (Exception e) {
            System.out.println("发生异常: " + e.getMessage());
        } finally {
            client.close();
        }
        return result;
    }

    /**
     * redis delete key
     */
    @PostMapping("/delete")
    public Long deleteKey(@RequestBody String Body) {
        String key = null;
        Long result = null;

        try {
            JSONObject jsonObject = new JSONObject(Body);
            key = jsonObject.getString("key");
            result = client.del(key);
        } catch (Exception e) {
            System.out.println("发生异常: " + e.getMessage());
        } finally {
            client.close();
        }
        return result;
    }

    /**
     * Body
     * {
     * pattern:'',
     * <p>
     * }
     * redis 模糊匹配
     */
    @PostMapping("/scan")
    public String scan(@RequestBody String Body) {
        String pattern = null;
        String result = null;
        List<String> resultList = new ArrayList<>();
        // 创建Gson对象
        Gson gson = new Gson();
        try {
            JSONObject jsonObject = new JSONObject(Body);
            pattern = jsonObject.getString("pattern");
            // 通配符，如label:*
            ScanParams scanParams = new ScanParams().match(pattern);
            String cursor = "0";
            // 当cursor为0时说明结束
            do {
                ScanResult<String> ScanResult = client.scan(cursor, scanParams);
                resultList.addAll(ScanResult.getResult());
                cursor = ScanResult.getCursor();
            } while (!cursor.equals("0"));
        } catch (Exception e) {
            System.out.println("发生异常: " + e.getMessage());
        } finally {
            client.close();
        }
        //转换为json字符串
        result = gson.toJson(resultList);
        //System.out.println(result);
        return result;
    }

}
