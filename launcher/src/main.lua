local f = love.graphics.newFont("Roboto-Regular.ttf", 40)
local x = "Проверка обновлений"
local t = love.graphics.newText(f, x)
local sw, sh = love.graphics.getDimensions()

function love.draw()
  love.graphics.draw(t, sw / 2 - f:getWidth(x) / 2, sh / 2 - f:getHeight(x) / 2)
end