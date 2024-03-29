﻿using Application.Service;
using Application.ViewModel.Value;
using Application.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IValueService _valueService;        
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ValuesController(IValueService valueService , ILogger<ValuesController> logger, IMapper mapper)
        {
            _valueService = valueService;            
            _logger = logger;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {   
            try
            {
                var values = await _valueService.GetAllAsync();
                return Ok(values);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id)
        {   
            try
            {
                var value = await _valueService.GetByIdAsync(id);

                if (value == null)
                {
                    return NotFound();
                }

                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }

        [HttpPost("addValue")]        
        public async Task<IActionResult> Post([FromBody] ValueForCreateDto valueForCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var valueToCreated = _mapper.Map<Value>(valueForCreateDto);
               
                await _valueService.AddAsync(valueToCreated);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        
        [HttpPut("updateValue/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ValueForUpdateDto valueForUpdateDto)
        {
            try
            {
                if (!ModelState.IsValid || id!=valueForUpdateDto.Id)
                {
                    return BadRequest();
                }                

                var valueForUpdated = _mapper.Map<Value>(valueForUpdateDto);

                _valueService.Update(valueForUpdated);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var selectedValue = await _valueService.GetByIdAsync(id);

                if (selectedValue == null)
                {
                    return NotFound();
                }

                var valueToDeleted = _mapper.Map<Value>(selectedValue);

                var deletedValue = _valueService.Delete(valueToDeleted);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
