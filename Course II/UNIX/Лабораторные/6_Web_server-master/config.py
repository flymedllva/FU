from enum import Enum


class Config(Enum):
    host = "localhost"
    port = 9000
    name = "Python3 Server"
    debug = True
    keep_alive = True
    favicon = "/favicon.ico"
    static = "/static"
    static_supported_format = ("HTML", "JPG", "JPEG", "PNG", "ICO", "JSON", "SVG", "SVGZ", "WOFF", "WOFF2", "MP4",
                               "MP3", "TTF", "JPG", "JPEG", "GIF", "PNG", "ICO", "SH", "AVI", "BIN", "CSS", "CSV",
                               "EPUB" "ZIP", "RAR", "DOC", "XLS", "PPT", "MID", "MIDI", "WAV", "RTF", "ICS", "JS",
                               "MPKG", "PDF", "TAR", "XML")
