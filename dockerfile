FROM node:18

# Install Docker CLI
RUN apt-get update && \
    apt-get install -y docker.io curl conntrack

# Install minikube
RUN curl -LO https://storage.googleapis.com/minikube/releases/latest/minikube-linux-amd64 && \
    install minikube-linux-amd64 /usr/local/bin/minikube && \
    rm minikube-linux-amd64

# Optional: install kubectl
# RUN curl -LO https://dl.k8s.io/release/$(curl -s https://dl.k8s.io/release/stable.txt)/bin/linux/amd64/kubectl && \
#     install kubectl /usr/local/bin/
