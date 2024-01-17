# Use the official MongoDB image
FROM mongo:latest

# Copy the scripts into the container
COPY scripts/create_collection.js /docker-entry-point-initdb.d/

# Expose the MongoDB portв
EXPOSE 27017

CMD ["mongod", "--bind_ip_all", "--port", "27017"]
