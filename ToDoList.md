﻿#labels Featured,Phase-Design,Phase-Implementation
#准备做的事情

## 正在处理 ##

  * Del.icio.us/Flickr/Twitter..整合进入每天的日志，并且输出到Feed[like facebook?](MiniFeed.md)
  * 相关：~~最近更新的~~ 前几日的，后几日的/内容最相关的
  * Archives Update：类似WordPress的层次分类，显示多少天，~~多少clip（已完成）~~。

## 等待处理的功能 ##

  * Tag for Clip, and aggregate to day/month/year/whole.

## 较独立的功能 ##

  * 页面、对象、数据和数据库相关的应用程序级缓存
  * 自定义http请求，将静态的文件从asp.net引擎重新做静态文件处理。
  * Blog Cache - Web Picks，独立的blog网摘系统，抓取相关的html、css等在本地储存，并且抓取远程屏幕截图。实现分布式储存。

## 确认中 ##


## 期待合作者分配 ##

  * 数据层扩展，支持Access。 ~~MySQL/Oracle~~
  * Avalon原生的独立Skin

## 远景版本预期 ##

  * 启用数据持久层，考虑NH，Castle，关注中
  * SQL查询从代码中分离，独立为储存过程
  * 大规模并发访问量支持
  * 好友系统，可信任的好友可以给clip添加和修改Tag