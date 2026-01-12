### 个人使用

#### 数据库：使用sqlite凑合一下：study.db文件

#### 前端:my-first-app，使用vu3+js+Pinia+ElementUIPlus

##### 启动方式：

安装node.js，安装npm包管理器，打开文件夹后运行：
~~~ bash
    cd my-first-app
    npm install
    npm run dev
~~~

##### 实现进度:

1. 基本布局 ok

    * elementUI-Plus左侧菜单布局 ok

    * 配置菜单路由 ok

2. 使用Pinia ok

    * 配置数据 ok

    * 组件调用、修改数据 ok

    * 修改后其他组件获取修改后的值 ok

    * 增加持久化功能，使用插件，可配置为刷新后不回滚为默认值 ok

3. 让需要的页面在对应的位置上 ok

    * 右上角的用户框，与操作按钮 ok
    
4. 实现多页签功能 ok

    * 点菜单动态添加tab页，并触发对应页面 ok

    * 点tab页触发切换 ok

5. 登录退出 ok

    * 登录与退出功能 ok

    * 路由守卫防止未登录访问 ok

6. 附加功能 ok

    * 翻页表格，获取行数据 ok

    * 弹框，值可以通过双向绑定获得 ok

    * 角色管理菜单权限,通过动态路由实现 ok

    * 按钮权限卡控 ok

7. 可视化 ok

    * 方案：使用Konva.js去实现

    * 基础图像实现 ok

    * 绑定事件 ok

    * 目标：实现layout布局，并允许配置属性，执行响应式的信息变化 ok

8. spc 异常判断案例，使用echarts

    * 异常1：点落在中心线3σ以外 ok

    * 异常2：连续超过9个点在中心线同一侧 ok

    * 异常3：连续6个点连续递增递减 ok

#### 后端：C#-server:C#后端功能实现

##### 基础工具

1. Nuget：包管理器，问题点：解决无法安装，参考环境部署

##### 启动方式：
1. webapi项目创建参考：https://learn.microsoft.com/zh-cn/training/modules/build-web-api-aspnet-core/3-exercise-create-web-api
~~~bash
    ## 创建项目
    dotnet new webapi -controllers
    ## 编译&启动项目
    dotnet run
~~~

##### 实现进度:

1. 连接数据库，e_sqlite3.dll需要放在bin文件下面 ok

2. jdbc实现sql参考：SQLiteCase1 ok

3. orm框架：Dapper，实现查询和非查询，支持参数化和对象操作 ok

4. webapi：实现get和post请求，controller案例：https://blog.csdn.net/LZYself/article/details/153929204 ok

  特殊点：（1）实现响应后返回json结果和前端的接收，和java保持一致 ok
    ~~~json
    {  "code ":200,  "message " : "成功", "data" : "{\"id\":1,\"Name\":\"am\"}" }
    ~~~
    （2） 使用扩展方法注册服务，实现依赖注入，和spring类型，需要注册对应的类才可使用 ok

#### 后端：java-server:java后端功能实现

实现对应的接口

##### 启动方式：
1. spring自动启动，打包为jar包即可

##### 实现进度:





