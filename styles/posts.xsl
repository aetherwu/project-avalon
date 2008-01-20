<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

	<!-- Single Article Templates-->
	<xsl:template match="posts">
		<xsl:variable name="owner" select="owner"  />
		<xsl:for-each select="post">
		<div class="box post {@type} fix">
		<div>
			<div class="caption">
				<xsl:for-each select="date">
					<xsl:choose>
						<xsl:when test="../../../person">
							<h2 class="date"><a href="/{../../../person}/{@address}"><xsl:value-of select="text()"/></a></h2>
						</xsl:when>
						<xsl:otherwise>
							<h2 class="date"><xsl:value-of select="text()"/></h2>
						</xsl:otherwise>
					</xsl:choose>					
				</xsl:for-each>
			</div>
			<div class="contain fix">
				<xsl:for-each select="clip">
					<div class="clip fix">
						<xsl:choose>
							<xsl:when test="not(../../../person)">
								<a href="/{owner}" class="face" target="new"><img src="/images/face/{owner}.jpg" /></a>
							</xsl:when>
						</xsl:choose>
						<div class="text" id="{../date/@address} {time}">
							<a href="{link}" class="source {source}" target="new"></a>							
							<div class="time">
								<xsl:choose>
									<xsl:when test="not(../../../person)">
										<span><xsl:value-of select="owner" /></span>
									</xsl:when>
								</xsl:choose>
								<xsl:value-of select="time" />
							</div>
							<p><xsl:apply-templates select="text"/></p>
						</div>
					</div>
				</xsl:for-each>
			</div>
		</div>
		</div>
		</xsl:for-each>
	</xsl:template>

	<xsl:template match="text">
		<xsl:copy-of select="node()"/>
	</xsl:template>

</xsl:stylesheet>
