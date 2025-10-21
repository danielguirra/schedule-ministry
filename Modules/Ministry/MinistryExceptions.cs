using ApiEscala.Exceptions;

namespace ApiEscala.Modules.Ministry
{
    public class MinistryNotFoundException(Guid? id)
        : Exception(
            id is null ? "Ministério não encontrado." : $"Ministério com ID {id} não encontrado."
        ),
            IHasHttpCode
    {
        public int Code => 404;
    }

    public class MinistryConflictException(string name)
        : Exception($"Já existe um ministério com o nome '{name}'."),
            IHasHttpCode
    {
        public int Code => 409;
    }

    public class InvalidMinistryDataException()
        : Exception("Os dados fornecidos para o ministério são inválidos."),
            IHasHttpCode
    {
        public int Code => 400;
    }

    public class InternalMinistryException()
        : Exception("Erro interno ao processar o ministério."),
            IHasHttpCode
    {
        public int Code => 500;
    }

    public class PermissionForbiddenMinistryException()
        : Exception("Você não tem permissão para modificar este ministério."),
            IHasHttpCode
    {
        public int Code => 403;
    }
}
