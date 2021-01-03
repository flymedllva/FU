import lxml.etree as ET

transform = ET.XSLT(ET.parse("t.xsl"))(ET.parse("d.xml"))
with open("r.html", "wb") as f:
    f.write(ET.tostring(transform, pretty_print=True, encoding="utf-8"))
