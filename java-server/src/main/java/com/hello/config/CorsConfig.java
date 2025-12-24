package com.hello.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.cors.CorsConfiguration;
import org.springframework.web.cors.UrlBasedCorsConfigurationSource;
import org.springframework.web.filter.CorsFilter;

@Configuration
public class CorsConfig {

    /**
     *
     * 配置类的作用，解决前后端跨域，允许某一ip的访问
     */
    @Bean
    public CorsFilter corsFilter() {
        UrlBasedCorsConfigurationSource source = new UrlBasedCorsConfigurationSource();
        CorsConfiguration config = new CorsConfiguration();
        config.setAllowCredentials(true); // 允许携带认证信息，如cookies等。
        config.addAllowedOrigin("http://localhost:8080"); // 允许的源地址
        config.addAllowedHeader("*"); // 允许任何头信息字段
        config.addAllowedMethod("*"); // 允许任何HTTP方法
        source.registerCorsConfiguration("/**", config); // 对所有路径生效
        return new CorsFilter(source);
    }
}