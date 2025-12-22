package test;

import com.hello.Application;
import com.hello.app.redisClient;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.core.env.Environment;
import redis.clients.jedis.params.ScanParams;
import redis.clients.jedis.resps.ScanResult;

import java.util.ArrayList;
import java.util.List;


/**
 * redis单元测试类
 */
@SpringBootTest(classes = Application.class)
public class redisTest {

    /**
     * 测试获取配置,必须注入对应的类方可使用对应的value值
     */
    @Autowired
    private redisClient client;

    @Autowired
    private Environment env;

    @Test
    void getSeting(){
        String host = env.getProperty("redis.host");
        String port = env.getProperty("redis.port");
        System.out.println(host);
        System.out.println(port);
//        System.out.println(client.getHost());
//        System.out.println(client.getPort());
    }
    @Test
    void pong(){
        String ping = client.ping();
        client.set("name","张三");
        System.out.println(client.get("name"));
        client.close();
    }

    @Test
    void scan(){
        List<String> result = new ArrayList<>();
        ScanParams scanParams = new ScanParams().match("label:*").count(1);
        String cursor = "0";
        do {
            ScanResult<String> ScanResult = client.scan(cursor, scanParams);
            System.out.println("匹配的keys: " + ScanResult.getResult());

            cursor = ScanResult.getCursor();
            result.addAll(ScanResult.getResult());
        } while (!cursor.equals("0"));
        System.out.println("结果集: " + result.toString());
    }
}
