'use strict';

module.exports = function () {
    let {modelName, dbTableName, serviceName, withTests} = this.props;

    this.fs.copyTpl(
        this.templatePath('ModelName.cs'),
        this.destinationPath(`DataAccess/Models/${modelName}.cs`), {
            ModelName: modelName,
        }
    );

    this.fs.copyTpl(
        this.templatePath('ModelNameDto.cs'),
        this.destinationPath(`Contracts/Models/${modelName}Dto.cs`), {
            ModelName: modelName,
        }
    );

    this.fs.copyTpl(
        this.templatePath('ModelNameProfile.cs'),
        this.destinationPath(`BusinessLogic/Mappers/${modelName}Profile.cs`), {
            ModelName: modelName,
        }
    );

    this.fs.copyTpl(
        this.templatePath('ModelNameRepository.cs'),
        this.destinationPath(`DataAccess/Repositories/${modelName}Repository.cs`), {
            ModelName: modelName,
            DbTableName: dbTableName
        }
    );

    this.fs.copyTpl(
        this.templatePath('ModelNameController.cs'),
        this.destinationPath(`Api/Controllers/${modelName}Controller.cs`), {
            ModelName: modelName,
        }
    );

    this.fs.copyTpl(
        this.templatePath('ServiceName.cs'),
        this.destinationPath(`BusinessLogic/Services/${serviceName}.cs`), {
            ModelName: modelName,
            ServiceName: serviceName,
        }
    );

    if (withTests) {
        this.fs.copyTpl(
            this.templatePath('ModelNameTest.cs'),
            this.destinationPath(`Api.Tests/${modelName}Test.cs`), {
                ModelName: modelName,
            }
        );
    }
};