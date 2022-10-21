Aplicativo em desenvolvimento.

Resumo:
	O aplicativo é inspirado no conceito de MinimalApi 
	Naturalmente é uma POC com tempo de desenvolvimento muito curto, então decidi focar nas regras de negócio em relação a entidades e fluxos (deixando interação com usuário final para depois).
	Em relação ao critério de desempate, compreendi que a data de inscrição era um critério mais fraco que penaltis e gols, portanto este ficou por ultimo na escala de importância.

Disponíveis:
* Service (métodos de criação de times, campeonatos, de desempate, geração de pontuação)
* Testes unitários: Teste de execução do script em Python

Não disponíveis:
* Banco de dados => Há problemas com implementação do banco (incompatibilidade de versionamento ou instalação incorreta de software).
* Controllers => Necessário desenvolver
