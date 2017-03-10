using System;
using System.Dynamic;
using System.Net;
using Bristlecone.ServiceLayer.Interfaces;

namespace Bristlecone.ServiceLayer.Common
{
    public class ResponseUtilities<T> : IResponseUtilities<T>
    {
        /// <summary>
        /// Creates a ResponseDTO for an Entity Created 
        /// </summary>
        /// <param name="createdObject">The object created</param>
        /// <param name="id">The id of the created object</param>
        /// <returns></returns>
        public ResponseDTO GetCreatedResponseDto(T createdObject, int id)
        {
            return new ResponseDTO()
            {
                Id = id,
                StatusCode = HttpStatusCode.Created,
                Message = $"{createdObject.GetType()} successfully created.",
                ReturnObject = createdObject
            };
        }

        /// <summary>
        /// Creates a ResponseDTO for an Entity Updated 
        /// </summary>
        /// <param name="updatedObject">The object updated</param>
        /// <returns></returns>
        public ResponseDTO GetUpdatedResponseDto(T updatedObject)
        {
            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.OK,
                Message = $"{updatedObject.GetType()} successfully updated.",
                ReturnObject = updatedObject
            };
        }

        /// <summary>
        /// Creates a ResponseDTO for an Entity Exception 
        /// </summary>
        /// <param name="ex">The Exception</param>
        /// <param name="message">The friendly message to pass back on the ResponseDTO</param>
        /// <returns></returns>
        public ResponseDTO GetExceptionResponseDto(Exception ex, string message)
        {
            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = $"An exception has occurred. Message: [{message}] Exception: [{ex.Message}]",
            };
        }

        /// <summary>
        /// Creates a ResponseDTO for an Entity Exception 
        /// </summary>
        /// <param name="ex">The Exception</param>
        /// <param name="failedObject">The object related to the Exception</param>
        /// <returns></returns>
        public ResponseDTO GetExceptionResponseDto(Exception ex, T failedObject)
        {
            var failedObjectName = (null == failedObject) ? null : failedObject.GetType();

            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Message = $"An exception for type {failedObjectName} has occurred. Exception: [{ex.Message}]",
            };
        }

        /// <summary>
        /// Creates a ResponseDTO for a duplicate Entity Exception 
        /// </summary>
        /// <param name="duplicateObject">The duplicate object</param>
        /// <returns></returns>
        public ResponseDTO GetDuplicateEntityResponseDto(T duplicateObject)
        {
            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Message = $"Error attempting to create {duplicateObject.GetType()}. {duplicateObject.GetType()} already exists.",
                ReturnObject = duplicateObject
            };
        }

        /// <summary>
        /// Creates a ResponseDTO for an Entity Not Found 
        /// </summary>
        /// <param name="notFoundObject">The not found object</param>
        /// <returns></returns>
        public ResponseDTO GetEntityNotFoundResponseDto(T notFoundObject)
        {
            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.NotFound,
                Message = $"Error attempting to get or update {notFoundObject.GetType()}. {notFoundObject.GetType()} not found.",
                ReturnObject = notFoundObject
            };
        }

        /// <summary>
        /// Creates a ResponseDTO containing a single property value
        /// </summary>
        /// <param name="propertyValue">The string property value being passed back.</param>
        /// <returns></returns>
        public ResponseDTO GetPropertyResponseDto(string propertyValue)
        {
            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.OK,
                Message = $"Property",
                ReturnObject = propertyValue
            };
        }

        /// <summary>
        /// Creates a ResponseDTO containing a single property value
        /// </summary>
        /// <param name="expando">The expando object to pass back</param>
        /// <returns></returns>
        public ResponseDTO GetPropertyResponseDto(ExpandoObject expando)
        {
            return new ResponseDTO()
            {
                StatusCode = HttpStatusCode.OK,
                Message = $"Property",
                ReturnObject = expando
            };
        }
    }
}