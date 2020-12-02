FROM node:13-alpine as build

RUN npm install -g @angular/cli@11.0.2

ADD ./package.json /app/
ADD ./package-lock.json /app/

WORKDIR /app
RUN npm install

ADD ./ /app/

RUN ng build --prod

FROM nginx:1.17-alpine as FINAL

ADD ./nginx.conf /etc/nginx/

COPY --from=build /app/dist/ngApp /usr/share/nginx/html

