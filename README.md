# Library-.NET_MVC_Layer
將ASP.NET MVC架構分層作專案分離以便日後單獨使用
* 分層
 ![](https://i.imgur.com/gNkajPL.png)
 1.  **Service**:替換資料來源介面
 2.  **Dao**:到MSSQL拿資料
 3.  **Model**:資料模型
 4.  **Tool**:專案共用工具
* View用Ajax傳json資料到controller
* DI-Spring(與Factory之比較)
* ORM-Dapper
* Log檔-Log4Net
* UniTest