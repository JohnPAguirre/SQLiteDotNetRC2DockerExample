& "C:\Program Files\Docker Toolbox\docker-machine.exe" env | Invoke-Expression
if (!(Test-Path .\Built)){
    mkdir .\Built
}
rm -r .\built\*
dotnet publish -o .\Built -f netcoreapp1.0 -r ubuntu.14.04-x64
docker rmi test
docker build -t test .
docker run -it --rm test


##Docker commands output to powershell objects, a little buggy when entries are blank
#$dockerOutput = docker images
#$dockerEntries = @()
#if ($dockerOutput -is [System.Array]) { 
#    $header = $dockerOutput[0] -split " \s{2,}"
#    For ($i = 0; $i -lt $dockerOutput.length; $i = $i + 1) {
#        #ignore first line
#        if ($i -eq 0) {continue}
#        #create objects    
#        $a = $dockerOutput[$i] -split " \s{2,}"
#        $dockerRunEntry = New-Object -TypeName "PSObject"
#        For ($y = 0; $y -lt $header.length; $y = $y + 1){
#            $header[$y] = $header[$y].Replace(" ", "_")
#            Add-Member -InputObject $dockerRunEntry -MemberType NoteProperty -Name $header[$y] -Value $a[$y]
#        }
#        $dockerEntries += $dockerRunEntry
#    }
#} 