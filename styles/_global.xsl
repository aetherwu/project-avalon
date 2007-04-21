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
					<h2 class="date"><a href="/{@address}"><xsl:value-of select="text()"/></a></h2>
				</xsl:for-each>
			</div>
			<div class="contain">
				<xsl:for-each select="clip">
					<div class="time"><xsl:value-of select="time" /></div>
					<div class="text"><xsl:apply-templates select="text"/></div>
				</xsl:for-each>
			</div>
			<div class="foot">
				<span class="history">
					<xsl:for-each select="date">
						<xsl:element name="a">
							<xsl:attribute name="href">http://door.woooh.com/index.php?q=uggc%3A%2F%2Fmu.jvxvcrqvn.bet%2Fjvxv%2F<xsl:value-of select="substring(@address,6,2)" />%25R6%259P%2588<xsl:value-of select="substring(@address,9,2)" />%25R6%2597%25N5</xsl:attribute>
							<xsl:attribute name="target">_blank</xsl:attribute>
							历史上的<xsl:value-of select="substring(text(),6,10)"/>
						</xsl:element>
					</xsl:for-each>
				</span>
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
					<a href="/{@address}"><xsl:value-of select="text()"/></a>
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

		<div class="box auther">
		<div>
			<h2 class="caption">在世者</h2>
			<div class="contain">
				<img src="http://photo7.yupoo.com/20070422/021144_488158533_vmvvmjsq.jpg" title="aether" />
			</div>
		</div>
		</div>

		<div class="box search">
		<div>
			<h2 class="caption">使用GoogleBlogger搜索</h2>
			<div class="contain">
				<form action="http://www.google.com/blogsearch" method="get" target="_blank">
					<input type="text" class="key" name="as_q" maxlength="50" value="" />
					<input type="submit" class="btn" value="翻翻看" />
					<input type="hidden" name="btnG" value="Search+Blogs" />
					<input type="hidden" name="bl_url" value="woooh.com" />
					<input type="hidden" name="scoring" value="d" />
				</form>
				搜索以后，你可以<b>订阅</b>你关注的更新：Email提醒，RSS源，或者是添加到你的Google自定义主页。
			</div>
		</div>
		</div>

		<xsl:for-each select="recentPosts">
		<div class="box recentPosts">
		<div>
			<h2 class="caption">最近记录</h2>
			<div class="contain">
				<ul class="">
					<xsl:for-each select="summary">
						<li>
							 <xsl:value-of select="text()" /> (<a href="/{@address}"><xsl:value-of select="@postTime"/></a>)
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
			<h2 class="caption">最近路过</h2>
			<div class="contain">
				<ul class="recentComments">
					<xsl:for-each select="summary">
						<li>
							<xsl:value-of select="text()" /> (<a href="{@logTime}"><xsl:value-of select="@guest"/></a>)
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
							<a href="/{@address}"><xsl:value-of select="text()"/></a>
							(<xsl:value-of select="@count" />)
						</li>
					</xsl:for-each>
				</ul>
			</div>
		</div>
		</div>
		</xsl:for-each>

		<div class="box store">
		<div>
			<h2 class="caption">土豆小店</h2>
			<div class="contain">
				<a href="http://auction1.taobao.com/auction/0/item_detail-0db1-d5b30540574212b2e0d1f2f889d822f6.jhtml" target="_blank"><img src="http://farm1.static.flickr.com/64/202756239_96fd48e300_s.jpg" title="土豆T恤衫" /></a>
				<a href="http://auction1.taobao.com/auction/0/item_detail-0db1-d5b30540574212b2e0d1f2f889d822f6.jhtml" target="_blank"><img src="http://farm1.static.flickr.com/70/202755611_ce043f5c55_s.jpg" title="土豆T恤衫" /></a>
				<a href="http://auction1.taobao.com/auction/0/item_detail-0db1-d5b30540574212b2e0d1f2f889d822f6.jhtml" target="_blank"><img src="http://farm1.static.flickr.com/63/202755383_0f14330cd6_s.jpg" title="土豆T恤衫" /></a>
				<a href="http://auction1.taobao.com/auction/0/item_detail-0db1-d5b30540574212b2e0d1f2f889d822f6.jhtml" target="_blank"><img src="http://farm1.static.flickr.com/68/202755850_5fb27d2416_s.jpg" title="土豆T恤衫" /></a>
			</div>
		</div>
		</div>

		<xsl:for-each select="links">
		<div class="box links">
		<div>
			<h2 class="caption">链接</h2>
			<div class="contain">
				<xsl:for-each select="group">
					<ul>
						<li class="sort"><xsl:value-of select="@sort"/></li>
						<xsl:for-each select="a">
						<li>
							<a href="{@href}" target="_blank"><xsl:value-of select="text()"/></a>
						</li>
						</xsl:for-each>
					</ul>
				</xsl:for-each>
			</div>
		</div>
		</div>
		</xsl:for-each>

		<div class="box archives">
		<div>
			<h2 class="caption">订阅</h2>
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
