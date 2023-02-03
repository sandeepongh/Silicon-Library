namespace Silicon_Library.Contracts.Services;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
