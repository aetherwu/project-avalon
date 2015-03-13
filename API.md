#可供外部调用的api，也可以供自己使用。

# API概述 #

调用地址：
  * http://avalonHost/api

指令：
  * new
  * ls
  * delete

# 指令和参数 #

## 添加新内容的指令 ##

命令：new

所需参数：

  * string m，唯一值new
  * string clip，不超过2000个汉字
  * string key，约定API-KEY

返回：
  * 成功的空响应

HTTP方法：POST

范例（使用POST）：
http://localhost/api
m=new
clip=测试
key=KEYSTRING

## 罗列最近记录的指令 ##

命令：ls

所需参数：
  * int page，默认值为0

返回：
  * 带有ID、时间和内容摘要的XML
  * 页码不存在错误

HTTP方法：GET

范例：
http://localhost/api?m=ls&page=10

## 删除指定记录的指令 ##

命令：delete

所需参数：
  * int id，默认值为0

返回：
  * 成功的空响应
  * 该指定的id不存在
  * 意外错误

HTTP方法：GET

范例：
http://localhost/api?m=delete&id=123
API