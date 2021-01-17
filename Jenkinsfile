pipeline {
    agent any
    triggers {
    pollSCM('* * * * *')
    }
    environment {
        dockerRegistry = "acrmicroserviceproject.azurecr.io"
        dockerRegistryUrl = "https://$dockerRegistry"
        dockerRegistryCredentials = 'ACRCredentials'
        
        authImageName = "productmicroservice"
        authImageBuildVersion = '1.0.0'
        authDockerImage = "$dockerRegistry/$authImageName:$authImageBuildVersion"
    }
    stages ('ProductMicroService') {
        
        stage ('Checkout') {
            steps {
                git credentialsId: 'GitHubCredentials', url: 'https://github.com/saidani300/ProductMicroService.git',branch: 'main'
            }
        }
        stage('Build and Test Image') {
            steps { 
                script {
                    sh "docker image build -f ProductMicroService/Dockerfile -t $env.authDockerImage ." 
                }
            }  
        }
        stage('Publish Image'){
            steps{
                script {
                    docker.withRegistry(env.dockerRegistryUrl, env.dockerRegistryCredentials){
                        sh "docker image push $env.authDockerImage"
                    }
                }
            }
        } 
          
    }
}
