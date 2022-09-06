FROM node:14-slim
WORKDIR /opt/node-todo-app
COPY . .
ENV PORT=4000
EXPOSE 4000
RUN npm install
CMD ["node", "app.js"]

# docker build . -t todo-app
# docker run todo-app
# docker run --name mongo-server -p 27017:27017 -d mongo
# docker run --link mongo-server:mongo-alias -p 4000:4000 todo-app