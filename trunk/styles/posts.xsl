﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >

	<!-- Single Article Templates-->
	<xsl:template match="posts">	
		<xsl:for-each select="post">
		<div class="box post {@type} fix">
		<div>
			<div class="caption">
				<xsl:for-each select="date">
					<h2 class="date"><a href="/{@address}"><xsl:value-of select="text()"/></a></h2>
				</xsl:for-each>
			</div>
			<div class="contain fix">
				<xsl:choose>
					<xsl:when test="./@type!=''">
						<div class="text ing needLogin"></div>
					</xsl:when>
				</xsl:choose>
					<xsl:for-each select="clip">
						<div class="time source{source}">
							<xsl:value-of select="time" />
							<xsl:choose>
								<xsl:when test="source[.='2']"><a href="{link}" target="_blank"><img src="http://static.woooh.com/images/goto.gif" class="goto" /></a></xsl:when>
							</xsl:choose>
						</div>
						<div class="text" id="{../date/@address} {time}">
							<xsl:apply-templates select="text"/>
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
