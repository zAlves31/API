# API de Autenticação de Dois Fatores (2FA)

Bem-vindo ao repositório da API de Autenticação de Dois Fatores (2FA). Esta API fornece um mecanismo seguro para implementar a autenticação de dois fatores em suas aplicações, aumentando a segurança dos usuários ao exigir uma segunda forma de verificação além da senha.

## Descrição

A API de 2FA permite que os desenvolvedores integrem um sistema de autenticação que utiliza dois fatores para validar a identidade do usuário. Isso pode incluir algo que o usuário conhece (como uma senha) e algo que o usuário possui (como um código gerado por um aplicativo autenticador, como o Google Authenticator).

## Funcionalidades

- **Registro de Usuário:** Permite que novos usuários se cadastrem e configurem a autenticação de dois fatores.
- **Geração de Código:** Gera um código de verificação único utilizando o pacote `GoogleAuthenticator`.
- **Verificação de Código:** Valida o código de verificação fornecido pelo usuário.
- **Gerenciamento de Sessões:** Controle de sessões ativas e opções para desativar a autenticação de dois fatores.

## Tecnologias Utilizadas

- **Node.js:** Ambiente de execução para construir a API.
- **Express:** Framework para gerenciar as rotas da API.
- **JWT (JSON Web Tokens):** Para autenticação e autorização segura.
- **GoogleAuthenticator:** Pacote utilizado para gerar e validar os códigos de autenticação.
