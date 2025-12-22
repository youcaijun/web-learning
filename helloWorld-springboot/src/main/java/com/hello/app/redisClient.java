package com.hello.app;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;
import redis.clients.jedis.Jedis;

/**
* redis客户端
* */
@Component
public class redisClient extends Jedis {
    /**
     * 使用子类时，想用父类的有参构造方法，必须将其纳入spring管理中
     * 调用指定ip和端口号
     */
    @Autowired
    public redisClient(@Value("${redis.host}")String host,@Value("${redis.port}")int port){
        super(host,port);
    }


}


