<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:georss="http://www.georss.org/georss" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
  xmlns:gco="http://www.isotc211.org/2005/gco"
  xmlns:srv="http://www.isotc211.org/2005/srv"
  xmlns:gmd="http://www.isotc211.org/2005/gmd"
>
  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="/">
    <MetaDataRecords>
      <MetaDataRecord>
        <!-- titel metadata bestand -->
        <xsl:apply-templates select="gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:title"/>
        <!-- dataset identifier -->
        <!-- 27042012@Mannus uitgezet na overleg met Eddy Coenen-->
        <!--
        <xsl:apply-templates select="gmd:MD_Metadata/gmd:fileIdentifier"/>
        -->
        <!-- abstract-->
        <xsl:apply-templates select="gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:abstract"/>
        <!-- docuuid -->
        <xsl:apply-templates select="gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:identifier/gmd:MD_Identifier/gmd:code"/>
      </MetaDataRecord>
    </MetaDataRecords>
  </xsl:template>

  <xsl:template match="gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:title">
    <name>
      <xsl:value-of select="gco:CharacterString"/>
    </name>
  </xsl:template>

  <xsl:template match="gmd:MD_Metadata/gmd:fileIdentifier">
    <datasetidentifier>
      <xsl:value-of select="gco:CharacterString"/>
    </datasetidentifier>
  </xsl:template>

  <xsl:template match="gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:abstract">
    <abstract>
      <xsl:value-of select="gco:CharacterString"/>
    </abstract>
  </xsl:template>

  <xsl:template match="gmd:MD_Metadata/gmd:identificationInfo/gmd:MD_DataIdentification/gmd:citation/gmd:CI_Citation/gmd:identifier/gmd:MD_Identifier/gmd:code">
    <docuuid>
      <xsl:value-of select="gco:CharacterString"/>
    </docuuid>
    <datasetidentifier>
      <xsl:value-of select="gco:CharacterString"/>
    </datasetidentifier>
  </xsl:template>
</xsl:stylesheet>