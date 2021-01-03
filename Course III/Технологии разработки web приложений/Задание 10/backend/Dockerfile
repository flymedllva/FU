##################################################################
######################## BUILD STAGE #############################
##################################################################

FROM snakepacker/python:all AS builder

RUN python3.8 -m venv /usr/share/python3/app

ADD requirements.txt /tmp/

RUN /usr/share/python3/app/bin/pip install -U pip setuptools wheel
RUN /usr/share/python3/app/bin/pip install -Ur /tmp/requirements.txt

RUN apt-get update && \
    apt-get install python-dev
RUN apt-get install -y gunicorn
RUN apt-get install -y python-gevent

#################################################################
####################### TARGET STAGE ############################
#################################################################

# Use the image version used on the build stage
FROM snakepacker/python:3.8

# Copy virtualenv to the target image
COPY --from=builder /usr/share/python3/app /usr/share/python3/app

# Copy app to image
ADD app /app
RUN chmod +x ./app

# Create a symlink to pip modules
RUN ln -snf /usr/share/python3/app/bin/gunicorn /usr/bin/
RUN ln -snf /usr/share/python3/app/bin/pytest /usr/bin/
RUN ln -snf /usr/share/python3/app/bin/uvicorn /usr/bin/

EXPOSE 8000
