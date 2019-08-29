from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField

class InputForm(FlaskForm):
	vectorX = StringField('Вхiдний вектор')

	submit = SubmitField('Побудувати інтерполяційний поліном')