pipeline {
    agent any
    triggers {
    pollSCM('* * * * *')
    }
    environment {
        dockerRegistry = "acrmicroserviceproject.azurecr.io"
        dockerRegistryUrl = "https://$dockerRegistry"
        dockerRegistryCredentials = 'ACRCredentials'
        
        authImageNameUser = "usermicroservice"
        authImageBuildVersionUser = '1.0.0'
        authDockerImageUser = "$dockerRegistry/$authImageNameUser:$authImageBuildVersionUser"
        
        authImageNameProduct = "productmicroservice"
        authImageBuildVersionProduct = '1.0.0'
        authDockerImageProduct = "$dockerRegistry/$authImageNameProduct:$authImageBuildVersionProduct"

        authImageNameAccount = "accountmicroservice"
        authImageBuildVersionAccount = '1.0.0'
        authDockerImageAccount = "$dockerRegistry/$authImageNameAccount:$authImageBuildVersionAccount"

        authImageNameInventory = "inventorymicroservice"
        authImageBuildVersionInventory = '1.0.0'
        authDockerImageInventory= "$dockerRegistry/$authImageNameInventory:$authImageBuildVersionInventory"

        authImageNameSale = "salemicroservice"
        authImageBuildVersionSale = '1.0.0'
        authDockerImageSale= "$dockerRegistry/$authImageNameSale:$authImageBuildVersionSale"
        
        authImageNameAPIgateway = "apigateway"
        authImageBuildVersionAPIgateway = '1.0.0'
        authDockerImageAPIgateway= "$dockerRegistry/$authImageNameAPIgateway:$authImageBuildVersionAPIgateway"
    }
    stages{
        
        stage ('Checkout') {
            steps {
                git credentialsId: 'GitHubCredentials', url: 'https://github.com/saidani300/ProjetPDS.git',branch: 'main'
            }
        }
        stage('Build and Test Image') {
            steps { 
                script {
                    sh "docker image build -f UserMicroService/Dockerfile -t $env.authDockerImageUser ." 
                }
            }  
        }
        stage('Publish Image'){
            steps{
                script {
                    docker.withRegistry(env.dockerRegistryUrl, env.dockerRegistryCredentials){
                        sh "docker image push $env.authDockerImageUser"
                    }
                }
            }
        } 
          
    }
}
