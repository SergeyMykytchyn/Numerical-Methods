from flask_wtf import FlaskForm
from wtforms import StringField, SubmitField

class InputForm(FlaskForm):
	Nv = StringField('Кiлькiсть вузлiв')

	submit = SubmitField('Побудувати згладжуючий сплайн')