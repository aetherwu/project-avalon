<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

<!-- Global Styles -->

	<!-- Single Article Templates-->
	<xsl:template match="posts">
	<div class="content">
		<xsl:for-each select="post">
		<div class="box post">
		<div>
			<div class="caption">
				<xsl:for-each select="date">
				<h2 class="date">
					<xsl:element name="a">
						<xsl:attribute name="href">/<xsl:value-of select="@address" /></xsl:attribute>
						<xsl:value-of select="text()"/>
					</xsl:element>				
				</h2>
				</xsl:for-each>
			</div>
			<div class="contain">
				<xsl:for-each select="clip">
					<div class="time"><xsl:value-of select="time" /></div>
					<div class="text"><xsl:apply-templates select="text"/></div>
				</xsl:for-each>
			</div>
		</div>
		</div>
		</xsl:for-each>
	</div>
	</xsl:template>

	<!-- Navigation -->
	<xsl:template match="navigation">
	<div class="navigation">
		<ul>
			<xsl:for-each select="archor">
				<li>
					<xsl:element name="a">
						<xsl:attribute name="href">/<xsl:value-of select="@address" /></xsl:attribute>
						<xsl:value-of select="text()"/>
					</xsl:element>
				</li>
			</xsl:for-each>
		</ul>
	</div>
	</xsl:template>

	<!-- Powered By -->
	<xsl:template match="about">
	<div class="about">
		Powered By <xsl:value-of select="project"/>_<xsl:value-of select="version"/><br/>
		Theme From <xsl:value-of select="theme"/><br/>
		Last Release In <xsl:value-of select="release"/><br/>
		<script src="http://www.google-analytics.com/urchin.js" type="text/javascript"></script>
		<script type="text/javascript">
			_uacct = "UA-59911-1";
			urchinTracker();
		</script>
	</div>
	</xsl:template>

	<xsl:template match="text">
		<xsl:copy-of select="node()"/>
	</xsl:template>

	<xsl:template match="relative">
	<div class="side">

		<div class="box search">
		<div>
			<h2 class="caption">搜索</h2>
			<div class="contain">
				<form action="http://www.google.com/search" method="get" target="_blank">
					<input type="text" class="key" name="q" maxlength="50" value="" />
					<input type="submit" class="btn" value="翻翻看" />
					<input type="hidden" name="sitesearch" value="woooh.com" checked="true" />
				</form>
			</div>
			<h2 class="caption">世界正在发生...</h2>
			<div class="contain">
				<embed src="http://static.twitter.com/flash/twitter_timeline_badge.swf" flashvars="user_id=754682&amp;color1=0x5b5b5b&amp;color2=0x111&amp;textColor1=0xdbdbdb&amp;textColor2=0xD6BE24&amp;backgroundColor=0xefefef&amp;textSize=12" width="205" height="300" quality="high" name="twitter_timeline_badge" allowScriptAccess="always" type="application/x-shockwave-flash" pluginspage="http://www.adobe.com/go/getflashplayer"></embed>
			</div>
		</div>
		</div>

		<xsl:for-each select="recentPosts">
		<div class="box recentPosts">
		<div>
			<h2 class="caption"><xsl:value-of select="@sortType" /></h2>
			<div class="contain">
				<ul class="">
					<xsl:for-each select="summary">
						<li>
							 <xsl:value-of select="text()" /> (<xsl:element name="a">
								<xsl:attribute name="href">/<xsl:value-of select="@address" /></xsl:attribute>
								<xsl:value-of select="@postTime"/>
							</xsl:element>)
						</li>
					</xsl:for-each>
				</ul>
			</div>
		</div>
		</div>
		</xsl:for-each>

		<xsl:for-each select="recentComments">
		<div class="box">
		<div>
			<h2 class="caption"><xsl:value-of select="@sortType" /></h2>
			<div class="contain">
				<ul class="recentComments">
					<xsl:for-each select="summary">
						<li>
							<xsl:value-of select="text()" /> (<xsl:element name="a">
								<xsl:attribute name="href">/<xsl:value-of select="@logTime" /></xsl:attribute>
								<xsl:value-of select="@guest"/>
							</xsl:element>)
						</li>
					</xsl:for-each>
				</ul>
			</div>
		</div>
		</div>
		</xsl:for-each>

		<xsl:for-each select="archives">
		<div class="box archives">
		<div>
			<h2 class="caption">浏览存档</h2>
			<div class="contain">
				<ul>
					<xsl:for-each select="month">
						<li>
							<xsl:element name="a">
								<xsl:attribute name="href">/<xsl:value-of select="@address" /></xsl:attribute>
								<xsl:value-of select="text()"/>
							</xsl:element>
							(<xsl:value-of select="@count" />)
						</li>
					</xsl:for-each>
				</ul>
			</div>
		</div>
		</div>
		</xsl:for-each>

		<div class="box archives">
		<div>
			<h2 class="caption">订阅并关注</h2>
			<div class="contain">
				<ul class="">
					<li><a href="http://rss.woooh.com"><img alt="feedsky" src="http://static.woooh.com/images/feed/feed.png"/></a></li>
					<li><a href="http://fusion.google.com/add?feedurl=http://rss.woooh.com">Google Reader</a></li>
					<li><a href="http://www.bloglines.com/sub/http://rss.woooh.com">Bloglines</a></li>
					<li><a href="http://add.my.yahoo.com/rss?url=http://rss.woooh.com">My Yahoo</a></li>
					<li><a href="http://www.zhuaxia.com/add_channel.php?url=http://rss.woooh.com">抓虾</a></li>
				</ul>
			</div>
		</div>
		</div>

		<!-- 
		<div id="editor"></div>
		<script type="text/javascript">
		var oFCKeditor = new FCKeditor( 'logbody' ) ;
		oFCKeditor.BasePath = '/editor/' ;
		oFCKeditor.ToolbarSet = 'Basic' ;
		oFCKeditor.Width = '100%' ;
		oFCKeditor.Height = '400' ;
		oFCKeditor.Value = '' ;
		oFCKeditor.Create() ;
		</script>
		 -->

	</div>
	</xsl:template>

</xsl:stylesheet>
