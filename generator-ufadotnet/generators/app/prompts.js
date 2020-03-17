'use strict';

module.exports = [
  {
    type: 'input',
    name: 'modelName',
    message: 'Название модели',
    default: 'ModelName'
  },
  {
    type: 'input',
    name: 'dbTableName',
    message: 'Идентификатор таблицы БД',
    default: 'DbTable'
  },
  {
    type: 'input',
    name: 'serviceName',
    message: 'Название сервиса',
    default: 'ServiceName'
  },
  {
    type: 'confirm',
    name: 'withTests',
    message: 'Генерировать тесты?',
    default: true
  }
];