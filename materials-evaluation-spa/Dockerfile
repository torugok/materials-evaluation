FROM node:18-alpine

WORKDIR /usr/src/app

COPY package*.json ./
COPY . ./

RUN npm install -g @angular/cli
RUN npm ci


EXPOSE 4200

CMD ng serve --host 0.0.0.0
