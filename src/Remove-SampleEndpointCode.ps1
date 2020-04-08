$ErrorActionPreference = 'Continue'
$VerbosePreference = 'Continue'

Remove-Item -Force -Path .\Api\V1\Controllers\HelloWorldController.cs
Remove-Item -Force -Path .\Api\V1\Services\HelloWorldControllerService.cs
Remove-Item -Force -Path .\Api\V1\Services\IHelloWorldControllerService.cs
Remove-Item -Force -Path .\Api\V1\Models\Requests\PowerBallRequest.cs
Remove-Item -Force -Path .\Api\V1\Models\Responses\GreetingResponseModel.cs
Remove-Item -Force -Path .\Api\V1\Models\Responses\PowerBallResponseModel.cs
Remove-Item -Force -Path .\Api\V1\Mappers\GreetingMappers.cs
Remove-Item -Force -Path .\Api\V1\Mappers\PowerBallResultsMappers.cs
Remove-Item -Force -Path .\Core\Domain\Dtos\GreetingDto.cs
Remove-Item -Force -Path .\Core\Domain\Dtos\PowerBallResultsDto.cs
Remove-Item -Force -Path .\Core\Domain\Repositories\IGreetingsRepository.cs
Remove-Item -Force -Path .\Core\Domain\Repositories\IPowerBallRepository.cs
Remove-Item -Force -Path .\Core\Domain\Services\HelloWorldService.cs
Remove-Item -Force -Path .\Core\Domain\Services\IHelloWorldService.cs
Remove-Item -Force -Path .\Core\Domain\GameResult.cs
Remove-Item -Force -Path .\Core\Domain\Greeting.cs
Remove-Item -Force -Path .\Core\Domain\PowerBallGame.cs
Remove-Item -Force -Path .\Infrastructure\Repositories\GreetingsRepository.cs
Remove-Item -Force -Path .\Infrastructure\Repositories\PowerBallRepository.cs
