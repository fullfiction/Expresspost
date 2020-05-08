FROM node:10
ENV NODE_ENV production
WORKDIR /usr/src/app
COPY ["/admin/package.json", "/admin/package-lock.json*", "/admin/npm-shrinkwrap.json*", "./"]
RUN npm install --production --silent
COPY /admin .
EXPOSE 3000
CMD ["npm", "run", "start"]