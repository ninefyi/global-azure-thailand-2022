# global-azure-thailand-2022

<picture>
  <source media="(prefers-color-scheme: dark)" srcset="https://user-images.githubusercontent.com/25423296/163456776-7f95b81a-f1ed-45f7-b7ab-8fa810d529fa.png">
  <img alt="Shows an illustrated sun in light color mode and a moon with stars in dark color mode." src="https://user-images.githubusercontent.com/25423296/163456779-a8556205-d0a5-45e2-ac17-42d089e3c3f8.png">
</picture>

Global Azure Thailand 2022

- [GitHub](https://github.com/)
- [Plugin](https://github.com/mc1arke/sonarqube-community-branch-plugin)
- [Azure-CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli)

### Instruction

1. [Run line by line of setup.azcli](setup.azcli)
2. ```kubectl config use-context aks-devsecops-admin```
3. ```kubectl create namespace my-sonarqube```
4. ```kubectl apply -f ./aks/postgres```
5. ```kubectl apply -f ./aks/sonarqube```
6. ```kubectl label namespace my-sonarqube cert-manager.io/disable-validation=true```
7. ```helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx```
8. ```helm repo add jetstack https://charts.jetstack.io```
9. ```helm repo update```
10. ``` 
    helm install nginx-ingress ingress-nginx/ingress-nginx `  
    --version 4.0.8 `
    --namespace my-sonarqube `
    --set controller.replicaCount=2 `
    --set controller.nodeSelector."kubernetes\.io/os"=linux `
    --set defaultBackend.nodeSelector."kubernetes\.io/os"=linux `
    --set controller.service.loadBalancerIP="[IP Address]" `
    --set controller.service.annotations."service\.beta\.kubernetes\.io/azure-load-balancer-resource-group"="rg-devsecops"
    ```
11. ```
    helm install cert-manager jetstack/cert-manager `
    --namespace my-sonarqube `
    --version "v1.7.2" `
    --set installCRDs=true `
    --set nodeSelector."kubernetes\.io/os"=linux
    ```
12. ```kubectl apply -f ./aks/cluster-issuer.yml```
13. ```az network public-ip list -g rg-aks-trial -o tsv --query "[].ipAddress"```
14. ```az network public-ip list -g rg-aks-trial -o tsv --query "[].dnsSettings.fqdn"```
15. ```kubectl apply -f ./aks/nginx.ingress.yml```
