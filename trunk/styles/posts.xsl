<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

	<!-- Single Article Templates-->
	<xsl:template match="posts">	
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
	</xsl:template>

	<xsl:template match="text">
		<xsl:copy-of select="node()"/>
	</xsl:template>

</xsl:stylesheet>
