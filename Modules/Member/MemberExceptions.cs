using ApiEscala.Exceptions;

namespace ApiEscala.Modules.Member
{
    public class MemberNotFoundException(Guid? id)
        : Exception(id is null ? "Membro não encontrado." : $"Membro com ID {id} não encontrado."),
            IHasHttpCode
    {
        public int Code => 404;
    }

    public class MemberConflictException(string name)
        : Exception($"Já existe um membro com o nome '{name}'."),
            IHasHttpCode
    {
        public int Code => 409;
    }

    public class InvalidMemberDataException()
        : Exception("Os dados fornecidos para o membro são inválidos."),
            IHasHttpCode
    {
        public int Code => 400;
    }

    public class InternalMemberException()
        : Exception("Erro interno ao processar o membro."),
            IHasHttpCode
    {
        public int Code => 500;
    }

    public class MemberPermissionForbiddenException()
        : Exception("Você não tem permissão para modificar esse membro."),
            IHasHttpCode
    {
        public int Code => 403;
    }
}
