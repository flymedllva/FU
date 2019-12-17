from server import HTTPServer, HTTPTemplate
from config import Config

server = HTTPServer(**{i.name: i.value for i in Config})


@server.route("/", methods=["GET"])
def index():
    table = "<table border='1'>"
    for i in range(1, 10):
        table += "<tr>"
        for j in range(1, 10):
            table += f"<td>{i * j}</td>"
        table += "</tr>"
    table += "</table>"
    html = "<h1>Hello h1</h1><h2>Hello h2</h2><a href='/static/1.jpg'><img src='/static/1.jpg' height='20%'></a>" \
           "<br><br><audio controls><source src='/static/1.mp3' type='audio/mpeg'>!!!<a href='/static/1.mp3'>" \
           f"Скачайть</a></audio>{table}"
    return HTTPTemplate.use_selected_type(html, type="HTML")


# В браузере GET вызовет 405
@server.route("/test.html", methods=["POST"])
def index():
    return HTTPTemplate.use_selected_type("<h1>Hello h1</h1><h2>Hello h2</h2>", type="HTML")


@server.route("/test.json", methods=["GET"])
def test_json():
    with open("./static/j.json", "r") as j:
        return HTTPTemplate.use_selected_type("".join(j.readlines()), type="JSON")


@server.route("/logs.log", methods=["GET"])
def logs():
    try:
        with open("server.log", "r") as f:
            return HTTPTemplate.use_selected_type("".join(f.readlines()), type="None")
    except FileNotFoundError:
        return HTTPTemplate.use_selected_type("", type="None")


@server.route("/1.jpg", methods=["GET"])
def jpg_1():
    with open("./static/1.jpg", "rb") as f:
        return HTTPTemplate.use_selected_type(f.read(), type="JPG")


server.run()
