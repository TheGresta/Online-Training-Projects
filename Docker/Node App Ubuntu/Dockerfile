FROM ubuntu:18.04
RUN apt-get update
RUN apt-get install curl -y
RUN curl -sl https://deb.nodesource.com/setup_10.x | bash
RUN apty-get install nodejs -y
COPY . /opt/node-add/
ENV channel=gresta
# CMD ["node", "/opt/node-app/index.js"];
WORKDIR /opt/node-add
CMD ["node", "index.js"];

# docker build . -t simple-node-app
# docker run simple-node-app