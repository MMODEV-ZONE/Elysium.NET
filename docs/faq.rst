.. _faq:

Perguntas Mais Frequentes
================================

Qual a segurança da Elysium.NET na comunicação entre servidor e cliente?
-------------------------------------------------------------------------------

Por motivos de compatibilidade entre o .NET Framework e o .NET Core, a Elysium.NET utiliza criptografia RSA com chave de 128bits combinado ao algoritmo AES-256.

O cliente roda no Linux?
-------------------------------

Não, tanto porque o módulo de Windows Forms não é suportado oficialmente pela .NET Core quanto pelo fato que, mesmo quando for, estes dependem de APIs exclusivas do Windows - o que requer uma reescrita completa do código dos formulários.