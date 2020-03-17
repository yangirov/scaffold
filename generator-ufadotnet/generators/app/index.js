'use strict';

var chalk = require('chalk');
var yosay = require('yosay');

var Generator = require('yeoman-generator');
var prompts = require('./prompts');
var writeFiles = require('./writing');

module.exports = class extends Generator {
    constructor(args, opts) {
        super(args, opts);
        this.option('babel'); 
    }

    prompting() {
        this.log(yosay(
            'Добро пожаловать в UfaDotNet ' + chalk.red('generator-ufadotnet') + ' генератор!'
        ));

        return this.prompt(prompts).then((props) => {
            this.props = props;
        });
    }

    writing() {
        console.log(writeFiles, 'Перемещаем файлы...');
        writeFiles.call(this);
    }

    end() {
        this.log(chalk.green('Всё готово!'));
    }
};