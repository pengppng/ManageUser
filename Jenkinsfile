pipeline {
    agent {
        docker {
            image 'cimg/node:18.20.2'
            args '-v /var/run/docker.sock:/var/run/docker.sock'
        }
    }


    environment {
        IMAGE_NAME = 'pannaporn/manageg5-client'
        // TAG = "${BUILD_NUMBER}"
        FULL_IMAGE = "${IMAGE_NAME}:${TAG}"
    }

    stages {
        stage('Checkout') {
            steps {
                git branch: 'main', credentialsId: 'jen-git', url: 'https://github.com/pengppng/ManageUser.git'
            }
        }

        stage('Build Frontend') {
            steps {
                dir('manageg5.client') {
                    sh 'npm install'
                    sh 'npm run build'
                }
            }
        }

        stage('Docker Build & Push') {
        steps {
            script {
                dir('manageg5.client') {
                    writeFile file: 'Dockerfile', text: '''
                        FROM nginx:alpine
                        COPY dist/ /usr/share/nginx/html
                        EXPOSE 80
                    '''
                    sh "docker build -t ${FULL_IMAGE} ."
                }

                // withCredentials([usernamePassword(credentialsId: 'DockerHub-id', usernameVariable: 'DOCKER_USER', passwordVariable: 'DOCKER_PASS')]) {
                //     sh """
                //         echo "$DOCKER_PASS" | docker login -u "$DOCKER_USER" --password-stdin
                //         docker push ${FULL_IMAGE}
                //     """
                //     }
                }
            }
        }


        stage('Hello') {
            steps {
                echo 'Hello!'
            }
        }
    }
}
