.. _Linux:

Rodando no Linux
==========================

.. warning:: O uso desta versão requer conhecimentos básicos de utilização de sistemas Linux, como Debian, Ubuntu ou CentOS.

Apesar desta seção ser majoritariamente focada em servidores Linux, é possível rodar também esta versão específica no Windows. Isso porque a biblioteca .NET Core 3.0 é utilizada para tal fim.

Requisitos
#########################
Inicialmente, precisaremos instalar as dependências que serão necessárias para executar o servidor:
:: 

   apt-get install -y git
   apt-get install -y dotnet-sdk
   
Feito isso, basta clonar o repositório da Elysium e dar *checkout* na versão server-core:
:: 

   git clone https://github.com/raijenki/elysium.git
   cd elysium/
   git checkout server-core

Compilando e Executando
#############################
   
Finalmente, basta compilar e executar:
:: 

   dotnet build
   cd Servidor/
   dotnet run

.. warning:: A compilação não move automaticamente os arquivos de dados do servidor para a pasta do binário! Lembre-se de fazer isso manualmente ou terá erro na execução.

Cliente em .NET Core
##########################
Por motivos de tecnologia, é atualmente impossível rodar o cliente em outros sistemas operacionais diferentes do Windows. Isso porque a biblioteca WinForms se utiliza de APIs exclusivas apenas para o Windows. Enquanto é possível futuramente migrar o cliente para a plataforma .NET Core, o que envolve uma ampla reestruturação do código, esta limitação ainda se aplicará.