<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:dc="http://purl.org/dc/elements/1.1/">
<xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" encoding="utf-8"/>

	<xsl:include href="/styles/_global.xsl" />
	<xsl:include href="/styles/posts.xsl" />
	
	<!-- Main Page Template-->
	<xsl:template match="avalon">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
				<meta http-equiv="Content-Language" content="zh-cn" />
				<title><xsl:value-of select="person"/></title>
				<link type="text/css" href="/styles/view.css" rel="stylesheet" media="screen"/>
				<link type="application/rss+xml" href="http://rss.woooh.com" rel="alternate" title="Aether的纪事 RSS 2.0"  />
				<script type="text/javascript" src="http://static.woooh.com/script/lib/jquery.js"></script>
				<script type="text/javascript" src="http://static.woooh.com/script/global.js"></script>
				<script type="text/javascript" src="http://static.woooh.com/script/view.js"></script>
			</head>
			<body>
				<xsl:apply-templates select="navigation" />
				<div class="frame fix">
					<div class="wrapper fix">
						<div class="banner"><h1><i><xsl:value-of select="name"/></i></h1></div>
						<div class="main">
							<div class="live">
								<div class="my">
									<div class="posts">
									<xsl:apply-templates select="my/posts" />
									</div>
								</div> 
								<table>
									<tr>
										<td>
										<xsl:apply-templates select="live/posts" />
										</td>
									</tr>
								</table>
								<xsl:apply-templates select="about" />
							</div>
						</div>
					</div>
				</div>
			</body>
		</html>
	</xsl:template>

	<!-- Comments Templates-->
	<xsl:template match="comments">
	<div class="comments">
		<xsl:choose>
			<xsl:when test="count(comment)>0">
				<div class="commentGuild"><xsl:value-of select="count(comment)" />条留言</div>
			</xsl:when>
		</xsl:choose>
		<xsl:for-each select="comment">
		<div class="box comment">
		<div class="inner">
			<div class="caption fix">
				<i><xsl:value-of select="position()" /></i>
				<xsl:choose>
					<xsl:when test="home[.!='http://']">
						<xsl:element name="a">
							<xsl:attribute name="href"><xsl:value-of select="home" /></xsl:attribute>
							<xsl:attribute name="target">new</xsl:attribute>
							<xsl:value-of select="author" />
						</xsl:element>
					</xsl:when>
					<xsl:otherwise>
						<xsl:value-of select="author" />
					</xsl:otherwise>
				</xsl:choose>
				<br/>
				<span><xsl:value-of select="postTime" /></span>
			</div>
			<div class="contain text"><xsl:apply-templates select="text"/></div>
		</div>
		</div>
		</xsl:for-each>
		<div class="commentGuild">想说点什么？</div>
		<div class="box comment commentPost">
		<div class="inner">
			<ul>
				<li><label for="guest">昵称</label>　<input id="guest" maxlength="20" class="input" type="text" name="guest" value="" /></li>
				<li><label for="home">主页</label>　<input id="home" maxlength="50" class="input" type="text" name="home" value="http://" />(可选)</li>
				<li><label for="message">留言，只支持纯文本</label> <textarea id="message" name="message" class="input" ></textarea ></li>
				<li>
					<input type="hidden" name="m" value="say" />
					<xsl:for-each select="//posts/post/date">
						<xsl:element name="input">
							<xsl:attribute name="type">hidden</xsl:attribute>
							<xsl:attribute name="id">day</xsl:attribute>
							<xsl:attribute name="name">day</xsl:attribute>
							<xsl:attribute name="value"><xsl:value-of select="@address" /></xsl:attribute>
						</xsl:element>
					</xsl:for-each>
					<input type="submit" class="submit" value=" 写上去 " />
				</li>
			</ul>
		</div>
		</div>
	</div>
	</xsl:template>

</xsl:stylesheet>
