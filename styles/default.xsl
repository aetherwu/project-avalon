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
				<title><xsl:value-of select="name"/></title>
				<link type="text/css" href="http://static.woooh.com/styles/default.css" rel="stylesheet" media="screen"/>
				<link type="application/rss+xml" href="http://rss.woooh.com" rel="alternate" title="RSS 2.0"  />
				<script type="text/javascript" src="http://static.woooh.com/script/lib/jquery.js"></script>
				<script type="text/javascript" src="/script/global.js"></script>
				<script type="text/javascript" src="http://static.woooh.com/script/scroll.js"></script>
				<script type="text/javascript" src="http://static.woooh.com/script/default.js"></script>
			</head>
			<body>
				<div class="banner">
					<h1><i><xsl:value-of select="name"/></i></h1>
					<xsl:apply-templates select="navigation" />
				</div>
				<div class="frame fix">
					<div class="wrapper fix">
						<div class="main">
							<div class="content">
								<xsl:apply-templates select="posts" />
							</div>
						</div>
						<xsl:apply-templates select="relative"/>
					</div>
				</div>
				<xsl:apply-templates select="about" />
			</body>
		</html>
	</xsl:template>

</xsl:stylesheet>