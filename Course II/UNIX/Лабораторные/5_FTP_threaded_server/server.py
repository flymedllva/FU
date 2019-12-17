from server import Server

if __name__ == '__main__':

    server = Server(port=9090)
    server.interactive = True
    server.start()
