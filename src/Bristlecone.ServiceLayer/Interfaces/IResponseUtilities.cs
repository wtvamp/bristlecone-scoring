using System;
using System.Dynamic;
using Bristlecone.ServiceLayer.Common;

namespace Bristlecone.ServiceLayer.Interfaces
{
    public interface IResponseUtilities<T>
    {
        ResponseDTO GetCreatedResponseDto(T createdObject, int id);
        ResponseDTO GetUpdatedResponseDto(T updatedObject);
        ResponseDTO GetExceptionResponseDto(Exception ex, string message);
        ResponseDTO GetExceptionResponseDto(Exception ex, T failedObject);
        ResponseDTO GetDuplicateEntityResponseDto(T duplicateObject);
        ResponseDTO GetEntityNotFoundResponseDto(T notFoundObject);

        ResponseDTO GetPropertyResponseDto(string propertyValue);
        ResponseDTO GetPropertyResponseDto(ExpandoObject expando);
    }
}