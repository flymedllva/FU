#################################################################
####################### TARGET STAGE ############################
#################################################################

FROM node:12-alpine

WORKDIR /usr/src/app

COPY package*.json ./
RUN npm install

COPY . .

RUN npm run-script build

EXPOSE 5000

ENV HOST=0.0.0.0

CMD [ "npm", "start" ]
