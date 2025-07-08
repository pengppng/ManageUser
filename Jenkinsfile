// pipeline {
//     agent {
//         docker {
//             image 'node:18-alpine'
//         }
//     }

//     stages {
//         stage('Checkout Code') {
//             steps {
//                 git credentialsId: 'jen-git', url: 'https://github.com/pengppng/ManageUser.git'
//             }
//         }

//         stage('Verify Node & NPM') {
//             steps {
//                 sh 'node -v && npm -v'
//             }
//         }

//         stage('Build Frontend') {
//             steps {
//                 dir('manageg5.client') {
//                     sh 'npm install'
//                     sh 'npm run build'
//                 }
//             }
//         }
//         // stage('Build Backend') {
//         //     steps {
//         //         dir('ManageG5.Server') {
//         //             sh 'dotnet restore'
//         //             sh 'dotnet build'
//         //         }
//         //     }
//         // }

//         stage('Test Frontend') {
//             steps {
//                 dir('manageg5.client') {
//                     sh 'npm run test -- --watch=false --browsers=ChromeHeadless || true'
//                 }
//             }
//         }
//          // stage('Test Backend') {
//         //     steps {
//         //         dir('ManageG5.Server') {
//         //             sh 'dotnet test'
//         //         }
//         //     }
//         // }

//         stage('Deploy Frontend') {
//             when {
//                 branch 'main'
//             }
//             steps {
//                 dir('manageg5.client') {
//                     sh '''
//                         docker stop my-angular-app || true
//                         docker rm my-angular-app || true
//                         docker build -t my-angular-app .
//                         docker run -d --name my-angular-app -p 8080:80 my-angular-app
//                     '''
//                 }
//             }
//         }

//         // stage('Deploy Backend') {
//         //     when {
//         //         branch 'main'
//         //     }
//         //     steps {
//         //         dir('ManageG5.Server') {
//         //             sh 'echo "Deploying backend..."'
                    
//         //         }
//         //     }
//         // }
//     }
// }


pipeline {
  agent any

  environment {
    DOCKERHUB_USER = "pannaporn"   // ✅ ใส่ Docker Hub Username
    IMAGE_NAME = "manageg5-client"
    KUBE_DEPLOY_DIR = "k8s"        // ✅ โฟลเดอร์ที่เก็บ YAML
  }

  stages {

    stage('Checkout Code') {
      steps {
        git credentialsId: 'jen-git', url: 'https://github.com/pengppng/ManageUser.git'
      }
    }

    stage('Build & Push Docker Image') {
      steps {
        script {
          docker.build("${DOCKERHUB_USER}/${IMAGE_NAME}")
          docker.withRegistry('', 'dockerhub-creds') {
            docker.image("${DOCKERHUB_USER}/${IMAGE_NAME}").push("latest")
          }
        }
      }
    }

    stage('Deploy to Kubernetes') {
      steps {
        script {
          withCredentials([string(credentialsId: 'kubeconfig', variable: 'KCFG')]) {
            writeFile file: 'kubeconfig.yaml', text: KCFG
            sh '''
              export KUBECONFIG=$PWD/kubeconfig.yaml
              kubectl apply -f ${KUBE_DEPLOY_DIR}/deployment.yaml
              kubectl apply -f ${KUBE_DEPLOY_DIR}/service.yaml
            '''
          }
        }
      }
    }
  }
}
