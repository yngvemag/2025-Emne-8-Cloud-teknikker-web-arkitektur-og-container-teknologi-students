# Setup Cloud Development Kit (CDK)

1. [Install node.js](https://nodejs.org/en/download)
2. Hvis problmer med å kjøre 'npm -v'
   - start powershell som administrator
   - kjør følgende kommandoer:
  
    ```bash
    # set policy
    Set-ExecutionPolicy -Scope CurrentUser -ExecutionPolicy RemoteSigned

    # verify
    Get-ExecutionPolicy -Scope CurrentUser
    ```

    - start powershell og test 'npm -v'
  
3. Kjør kommandoer:
   ```bash

    aws configure (hvis ikke CLI er satt opp)

    # install aws-cdk
    npm install -g aws-cdk

        added 1 package in 3s
        npm notice
        npm notice New major version of npm available! 10.9.2 -> 11.0.0
        npm notice Changelog: https://github.com/npm/cli/releases/tag/v11.0.0
        npm notice To update run: npm install -g npm@11.0.0
        npm notice


    # update version
    npm install -g npm@11.0.0

   ``` 