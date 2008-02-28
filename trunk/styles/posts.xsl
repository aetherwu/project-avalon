<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

	<!-- Single Article Templates-->
	<xsl:template match="posts">

		<xsl:for-each select="post">
			<xsl:call-template name="box" />
		</xsl:for-each>

	</xsl:template>

	<xsl:template name="box">
		<xsl:param name="postType"/>
		<div class="box {$postType} fix">
		<div class="post">
			<div class="caption fix">
				<xsl:for-each select="date">
					<h2 class="date"><a href="/{//avalon/person}/{@address}"><xsl:value-of select="text()"/></a></h2>
				</xsl:for-each>
				<xsl:for-each select="differ">
					<span class="differ"><xsl:value-of select="text()"/></span>
				</xsl:for-each>
			</div>
			<div class="contain fix">
				<xsl:for-each select="clip">
					<div class="clip fix">
						<div class="text" id="{../date/@address} {time}">
							<a href="{link}" class="source {source}" target="new"></a>							
							<div class="time">
								<xsl:value-of select="time" />
							</div>
							<p><xsl:apply-templates select="text"/></p>
						</div>
					</div>
				</xsl:for-each>
			</div>
		</div>
		</div>
	</xsl:template>

	<xsl:template match="text">
		<xsl:copy-of select="node()"/>
	</xsl:template>

</xsl:stylesheet>
