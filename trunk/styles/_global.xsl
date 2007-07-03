<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

<!-- Global Styles -->


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

	<xsl:template match="relative">
	<div class="side">

		<div class="box search">
		<div>
			<h2 class="caption">搜索</h2>
			<div class="contain">
				<form action="http://www.google.com/blogsearch" method="get" target="_blank">
					<input type="text" class="key" name="as_q" maxlength="50" value="" />
					<input type="submit" class="btn" value="翻翻看" />
					<input type="hidden" name="btnG" value="Search+Blogs" />
					<input type="hidden" name="bl_url" value="woooh.com" />
					<input type="hidden" name="scoring" value="d" />
				</form>
				<a href="http://rss.woooh.com"><img alt="feedsky" src="http://static.woooh.com/images/feed/rss.gif"/></a>

				<a href="http://labs.v2ex.com" target="_blank"><img src="http://static.woooh.com/images/labs.jpg"  style="margin-top:15px"/></a>
			</div>
		</div>
		</div>

		<div class="box share">
		<div>
			<h2 class="caption">
				<span><a href="http://del.icio.us/blogif">更多</a></span>
				近日阅读
			</h2>
			<div class="contain">
				<div id="share"></div>
				<script src="http://static.woooh.com/script/greader.js" type="text/javascript">
				</script>
				<script src="http://www.google.com/reader/public/javascript/user/12097899290454920167/label/webpick?n=10&amp;callback=GRC_p%28%7Bc:%27-%27,t:%27%27,s:%27false%27%7D%29;new%20GRC" type="text/javascript">
				</script>
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

		<xsl:for-each select="blogosphere">
		<div class="box blogosphere">
		<div>
			<h2 class="caption">链接</h2>
			<div class="contain">
				<xsl:for-each select="group">
					<ul class="{@sort}">
						<li class="sort"><xsl:value-of select="@sort"/></li>
						<xsl:for-each select="person">
						<li>
							<a href="{@blog}" target="_blank"><xsl:value-of select="text()"/></a>
						</li>
						</xsl:for-each>
					</ul>
				</xsl:for-each>
				<a href="javascript://" class="more">查看全部</a>
			</div>
		</div>
		</div>
		</xsl:for-each>

		<div class="box archives">
		<div>
			<xsl:for-each select="archives">
				<h2 class="caption">浏览存档</h2>
				<div class="contain">
					<select id="archives">
						<option value="/">选择存档月份</option>
						<xsl:for-each select="month">
							<option value="/{@address}"><xsl:value-of select="text()"/>(<xsl:value-of select="@count" />)</option>
						</xsl:for-each>
					</select>
				</div>
			</xsl:for-each>
		</div>
		</div>

	</div>
	</xsl:template>

</xsl:stylesheet>
