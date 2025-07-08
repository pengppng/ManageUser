# Build stage
FROM node:18 AS build
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build --prod

# Production stage
FROM nginx:alpine
COPY --from=build /app/dist/manageg5.client /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]


