$projectName=$args[0]
$ambiente=$args[1]
write-host "Parametros defaults, Sintaxe customizada: run-api.ps1 mesa_pro local|dev|tst|hml|prd" 
write-host "Parametros defaults, default: run-api.ps1 mesa_pro local" 

if ($null -eq $projectName) {
    $projectName = "mesa_pro"
}

if ($null -eq $ambiente) {
    $ambiente = "local"
}

$dockerProjectName=$projectName + '_api_' + $ambiente
$dockerFileName='docker-comp-api-' + $ambiente + '.yml'

docker-compose -p $dockerProjectName -f ./devops/apis/mesa-pro/$dockerFileName down