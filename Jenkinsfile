pipeline {
    agent any

    stages {
        stage('Build Frontend') {
            steps {
                dir('manageg5.client') {
                    sh 'npm install'
                    sh 'npm run build' // or use ng build
                }
            }
        }

        stage('Build Backend') {
            steps {
                dir('ManageG5.Server') {
                    sh 'dotnet restore'
                    sh 'dotnet build'
                }
            }
        }

        stage('Test Frontend') {
            steps {
                dir('manageg5.client') {
                    sh 'npm run test -- --watch=false --browsers=ChromeHeadless'
                }
            }
        }

        stage('Test Backend') {
            steps {
                dir('ManageG5.Server') {
                    sh 'dotnet test'
                }
            }
        }

        stage('Deploy Frontend') {
            when {
                branch 'main'
            }
            steps {
                dir('manageg5.client') {
                sh '''
                    docker stop my-angular-app || true
                    docker rm my-angular-app || true
                    docker build -t my-angular-app .
                    docker run -d --name my-angular-app -p 8080:80 my-angular-app
                '''
                }
            }
        }


        stage('Deploy Backend') {
            when {
                branch 'main'
            }
            steps {
                dir('ManageG5.Server') {
                    sh 'echo "Deploying backend..."'
                    // Add your real deploy command here
                }
            }
        }
    }
}
